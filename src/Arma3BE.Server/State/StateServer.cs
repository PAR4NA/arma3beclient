﻿using System.Collections.Generic;
using System.Linq;
using Arma3BE.Server.Models;
using Arma3BEClient.Common.Core;

namespace Arma3BE.Server.State
{
    public class StateServer : DisposeObject
    {
        private readonly object _lock = new object();
        private readonly Queue<ChatMessage> _messages = new Queue<ChatMessage>();
        private volatile Player[] _players;
        private BEServer _server;

        public IEnumerable<Player> Players => _players;

        public StateServer(BEServer server)
        {
            _server = server;

            _server.PlayerHandler += _server_PlayerHandler;
            _server.ChatMessageHandler += _server_ChatMessageHandler;
        }

        private void _server_ChatMessageHandler(object sender, ChatMessage e)
        {
            _messages.Enqueue(e);
            while (_messages.Count > 100)
                _messages.Dequeue();
        }

        private void _server_PlayerHandler(object sender, UpdateClientEventArgs<IEnumerable<Player>> e)
        {
            _players = e.Data.ToArray();
        }

        protected override void DisposeManagedResources()
        {
            if (_server != null)
            {
                lock (_lock)
                {
                    if (_server != null)
                    {
                        _server.PlayerHandler -= _server_PlayerHandler;
                        _server.ChatMessageHandler -= _server_ChatMessageHandler;

                        if (_server.Connected) _server.Disconnect();

                        _server.Disconnect();
                        _server.Dispose();
                        _server = null;
                    }
                }
            }
            base.DisposeManagedResources();
        }
    }
}