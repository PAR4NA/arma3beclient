using System;
using System.Collections.Generic;
using System.Linq;
using Arma3BEClient.Libs.ModelCompact;

namespace Arma3BEClient.Libs.Context
{
    public class ServerInfoRepository : IDisposable
    {
        public void Dispose()
        {
        }

        public IEnumerable<ServerInfo> GetActiveServerInfo()
        {
            using (var dc = new Arma3BeClientContext())
            {
                return dc.ServerInfo.Where(x => x.Active).ToList();
            }
        }

        public IEnumerable<ServerInfo> GetServerInfo()
        {
            using (var dc = new Arma3BeClientContext())
            {
                return dc.ServerInfo.ToList();
            }
        }

        public void SetServerInfoActive(Guid serverInfoId, bool active)
        {
            using (var dc = new Arma3BeClientContext())
            {
                var server = dc.ServerInfo.FirstOrDefault(x => x.Id == serverInfoId);
                if (server != null)
                {
                    server.Active = active;
                    dc.SaveChanges();
                }
            }
        }

        public IEnumerable<ServerInfo> GetNotActiveServerInfo()
        {
            using (var dc = new Arma3BeClientContext())
            {
                return dc.ServerInfo.Where(x => !x.Active).ToList();
            }
        }
    }
}