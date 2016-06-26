using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class OdgovorModel
    {
        public int Id { get; set; }

        [Display(Name="Tekst odgovora:")]
        public string Text { get; set; }

        [Display(Name = "Odobreno")]
        public int Odobreno { get; set; }

        [Display(Name = "Broj pozitivnih ocena:")]
        public int Pozitivno { get; set; }

        [Display(Name = "Broj negativnih ocena:")]
        public int Negativno { get; set; }

        [Display(Name = "Datum i vreme odgovora:")]
        public DateTime DatumVreme { get; set; }

        public string AutorOdgovora { get; set; }

        public int AutorId { get; set; }

        public IList<KomentarModel> Komentari;

        public OdgovorModel()
        {
            Komentari = new List<KomentarModel>();
        }

    }


    public  class OdgovoriModel
    {
        public List<OdgovorModel> ListaOdgovora { get; set; }

        public OdgovoriModel(params OdgovorModel[] ViseOdgovora)
        {
            ListaOdgovora = new List<OdgovorModel>();

            foreach (var OdgovorModel in ViseOdgovora)
            {
                ListaOdgovora.Add(OdgovorModel);
            }
        }
    }
}