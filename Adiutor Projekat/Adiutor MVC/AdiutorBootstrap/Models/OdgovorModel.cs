using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AdiutorBootstrap.Models
{
    public class OdgovorModel
    {
        [Display(Name="Tekst odgovora:")]
        public string Text { get; set; }

        [Display(Name = "Odobreno")]
        public bool Odobreno { get; set; }

        [Display(Name = "Broj pozitivnih ocena:")]
        public int Pozitivno { get; set; }

        [Display(Name = "Broj negativnih ocena:")]
        public int Negativno { get; set; }

        [Display(Name = "Datum i vreme odgovora:")]
        public DateTime DatumVreme { get; set; }

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