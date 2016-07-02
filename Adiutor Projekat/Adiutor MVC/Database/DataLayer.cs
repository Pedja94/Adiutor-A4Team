using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Database.Mapiranja;
using Oracle.ManagedDataAccess;

namespace Database
{
    public class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();


        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                //var cfg = OracleManagedDataClientConfiguration.Oracle10
                //.ShowSql()
                //.ConnectionString(c =>
                //    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S14826;Password=a4rules"));

                //var cfg = OracleManagedDataClientConfiguration.Oracle10
                //.ShowSql()
                //.ConnectionString(c =>
                //    c.Is("Data Source=140.86.6.15:1521/adiutor;User Id=system;Password=a4rules_Adiutor"));

                OracleConnectionStringBuilder con = new OracleConnectionStringBuilder();
                con.Server("140.86.6.15");
                con.Username("system");
                con.Password("a4rules_Adiutor");
                con.Port(1521);
                con.Instance("adiutor");

                var cfg = OracleManagedDataClientConfiguration.Oracle10
                    .ConnectionString(con.ToString());

              
                return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StatusMapiranja>())
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                System.Console.WriteLine(ec.Message);
                return null;
            }

        }
    }
}
