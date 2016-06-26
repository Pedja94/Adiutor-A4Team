
window.onload=function(){
    function nactajFormuZaKomentar(id) {
        if(document.getElementById(id)==null){
            var odgovor = document.getElementsByClassName(id)[0];
            var komentar=document.createElement("textarea");
            komentar.type="text";
            komentar.size=25;
            komentar.id=id;

            var roditelj=document.getElementById("odgovori");

            roditelj.insertBefore(komentar,odgovor.nextSibling);

            var predajKomentar=document.createElement("a");
            predajKomentar.innerHTML="Posalji";
            predajKomentar.className="btn btn-default";
            predajKomentar.id="dugme"+id;
            predajKomentar.href="javascript:posaljiPodatke("+id+","+document.getElementById(id).nodeValue+")";
            predajKomentar.onclick="javascript:posaljiPodatke("+id+","+document.getElementById(id).nodeValue+")";


            roditelj.insertBefore(predajKomentar, komentar.nextSibling);

        }
        else{
            var roditelj=document.getElementById(id).parentNode;
            var child=document.getElementById(id);

            var dugme=document.getElementById("dugme"+id);

            roditelj.removeChild(child);
            roditelj.removeChild(dugme);

        }
    }

    function posaljiPodatke(odgovorId, tekstKomentara)
    {
        var tekstKomentara = document.getElementById(odgovorId).innerHTML;
        var tekst = document.getElementById(odgovorId);
        var samtekst = tekst.value;
        var idOdgovora=odgovorId;

        var modelKomentara={ Text:samtekst, OdgovorId:idOdgovora, AutorId:@Session["Id"]};

        //alert(JSON.stringify(modelKomentara));
    
        $.get("DodajKomentar1", modelKomentara, function (data) {
            var string="kom+"+data.OdgovorId;
            var app=document.getElementById(string);

            var date = new Date(data.DatumVreme);
                            
            var tabelaZaKomentar=document.createElement("table");
            tabelaZaKomentar.classList="tableZaKomentar";

            var imeIVreme=document.createElement("tr");

            var ime=document.createElement("td");
            ime.innerHTML=data.ImeAutora;

            var vreme=document.createElement("td");
            vreme.innerHTML=date;

            imeIVreme.appendChild(ime);
            imeIVreme.appendChild(vreme);

            tabelaZaKomentar.appendChild(imeIVreme);


            var kreiraniElement=document.createElement("tr");
            kreiraniElement.innerHTML=data.Text;
            kreiraniElement.classList="paragrafiKomentari";
            kreiraniElement.setAttribute("colspan",2);
                            
            tabelaZaKomentar.appendChild(kreiraniElement);

            app.appendChild(tabelaZaKomentar);
            //$("#"+string).append("<div>" + data.Text + "</div>");
                            
            var roditelj=document.getElementById(data.OdgovorId).parentNode;
            var child=document.getElementById(data.OdgovorId);

            var dugme=document.getElementById("dugme"+data.OdgovorId);

            roditelj.removeChild(child);
            roditelj.removeChild(dugme);

        });



           

    }


}

