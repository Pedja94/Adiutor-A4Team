using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using NHibernate;
using Database.Entiteti;
using Database;
using NHibernate.Linq;
using Business.DataAccess;
using Business.DTO;

namespace Bussines.DataAccess
{
    public static class Pitanja_Tagovi
    {
        public static void Dodaj(Pitanje_TagDTO c)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Pitanje p = new Pitanje()
                {
                    Id = c.PitanjeId
                };


                Tag t = new Tag()
                {
                    Id = c.TagId
                };

                Pitanje_Tag Pitanje_Tag = new Pitanje_Tag()
                {
                    Pitanje = p,
                    Tag = t
                };

                s.SaveOrUpdate(Pitanje_Tag);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static public void Obrisi(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Pitanje_Tag st = s.Load<Pitanje_Tag>(id);

                s.Delete(st);
                s.Flush();
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        static public Pitanje_TagDTO Nadji(int PitanjeId, int TagId)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PitanjeDTO pitanje = Pitanja.Procitaj(PitanjeId);
                TagDTO tag = Tagovi.Procitaj(TagId);

                Pitanje_Tag pt = (from k in s.Query<Pitanje_Tag>()
                                   where (k.Pitanje.Id == pitanje.Id && k.Tag.Id == tag.Id)
                                   select k).Single();

                Pitanje_TagDTO ptdto = new Pitanje_TagDTO
                {
                    PitanjeId = pt.Pitanje.Id,
                    TagId = pt.Tag.Id
                };

                s.Flush();
                s.Close();

                return ptdto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
