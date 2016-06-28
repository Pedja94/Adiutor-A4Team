//window.onload=function()
//{
//    //var lista = new ListePredmeta();
//    //lista.crtaj();
 

//}



function ListePredmeta()
{
    this.Isemestar = ["Matematika 1", "Osnovi elektrontehnike 1", "Fizika", "Uvod u računarstvo", "Laboratorijski praktikum - Fizika", "Laboratorijski praktikum - Uvod u računarstvo"];
    this.IIsemestar = ["Matematika 2", "Osnovi elektrotehnike 2", "Algoritmi i programiranje", "Elektronske komponente", "Laboratorijski praktikum - Algoritmi i programiranje", "Laboratorijski praktikum - Osnovi elektrotehnike"];

    this.IIIsemestarRII = ["Objektno orijentisano programiranje", "Digitalna elektronika", "Logičko projektovanje", "Diskretna matematika", "Računarski sistemi"];
    this.IVsemestarRII = ["Strukture podataka", "Baze podataka", "Arhitektura i organizacija računara", "Programski jezici", "Matematički metodi u računarstvu"];

    this.VsemestarRII = ["Operativni sistemi", "Računarske mreže", "Objektno orijentisano projektovanje", "Engleski jezik 1", "Telekomunikacije", "Automatika", "Osnovi analize signala i sistema", "Elektronska merenja"];
    this.VIsemestarRII = ["Softversko inženjerstvo", "Veštačka inteligencija", "Mikroračunarski sistemi", "Engleski jezik 2", "Web programiranje", "Sistemi baza podataka", "Interakcija čovek-računar", "Informacioni sistemi"];
    
    this.VIIsemestarRII=[];
    this.VIIIsemestarRII=[];

    this.IIIsemestarENER = ["Električna kola", "Električna kola","Osnovi elektronike", "Metrologija električnih veličina", "Elektromehaničko pretvaranje energije","Elektrotehnički materijali"];
    this.IVsemestarENER = ["Transformatori i mašine jednosmerne struje", "Električne instalacije","Prenos električne energije","Modeliranje i simulacija dinamičkih sistema","Merenja u elektroenergetici","Tehnička mehanika","Distributivne i industrijske mreže"];

    this.VsemestarENER = ["Engleski jezik","Mašine naizmenične struje","Elektromagnetika","Automatsko upravljanje","Elektroenergetske komponente","Elektronska merenja","Kvalitet električne energije","Upravljanje procesima"];
    this.VIsemestarENER = ["Engleski jezik 2","Osnovi energetske elektornike","Elektroenergetska postrojenja","Dijagnostika i monitoring električnih mašina","Programabilni logički kontroleri","Elektroenergetska kablovska tehnika"];

    this.VIIsemestarENER = ["Elektrane", "Elektromotorni pogoni", "Zaštita u elektroenergetici", "Elektroenergetski pretvarači", "Numerička analiza", "Osvetljenje", "Sistemi automatskog upravljanja", "Izvori za napajanje"];
    this.VIIIsemestarENER = ["Odabrana poglavlja iz elektromotornih pogona","Analiza elektroenergetskih mreža","Sistemi za upravljanje i nadzor u industriji","Uzemljivači","Industrijski sistemi za merenje i kontrolu"];

    this.IIIsemestarEKM = ["Osnovi elektronike","Matematika III","Osnovi elektronike","Metrologija električnih veličina","Signali i sistemi","Materijali za elektroniku"];
    this.IVsemestarEKM = ["Telekomunikacije","Osnovi optike","Poluprovodničke komponente","Komponente za telekomunikacije","Projektovanje materijala za elektroniku","Osnovi kvantne i statističke fizike","Sistemi za vođenje EM talasa","Statistika i verovatnoća"];

    this.VsemestarEKM = ["Engleski jezik I","Analogna mikroelektronika","Optoelektronika","Novi materijali i tehnologije","Statističke metode kontrole kvaliteta","Karakterizacija materijala","Tehnologije mikrosistema","Projektovanje štampanih ploča"];
    this.VIsemestarEKM = ["Engleski jezik II","Senzori i pretvarači","Digitalna mikroelektronika","MEMS komponente","Tehnika i primena lasera","Numerička analiza PDJ","Mikroprocesorska tehnika","Merenje neelektričnih veličina","Mikrotalasna elektronika"];

    this.VIIsemestarEKM = ["Komponente i kola snage","Projektovanje i simulacija mikroelektronskih komponenata","Solarne komponente i sistemi","Projektovanje mikrosistema","Niskotemperaturna mikroelektronika","Obnovljivi izvori energije","Fizika jonizovanih gasova i plazme","Medicinska fizika","Analiza pouzdanosti","Materijali za nove i alternativne izvore energije","Izvori za napajanje","Održivo projektovanje","Projektovanje VLSI"];
    this.VIIIsemestarEKM = ["Modeliranje i simulacija mikroelektronskih komponenata i kola","Mikrokontroleri i programiranje","Inteligentne komponente snage","Mikrotalasne tehnologije i komponente","Laserska elektronika","Pouzdanost elektronskih komponenata i mikrosistema","Dozimetrija i dozimetri","Vakuumske i gasne komponente","Merenja u mikroelektronici","Ekonomija održive proizvodnje","Termovizija"];


    this.crtaj=function()
    {
        

        var Isem= document.getElementById("semestar1");
        var self = this;
        Isem.onclick = function () {
            self.crtajIsem();
        }

        var IIsem = document.getElementById("semestar2");
        var self = this;
        IIsem.onclick = function () {
            self.crtajIIsem();
        }

        var IIIsemRII = document.getElementById("semestar3RII");
        var self = this;
        IIIsemRII.onclick=function() 
        {
            self.crtajRIIsemestarIII();
        }

        var IVsemRII = document.getElementById("semestar4RII");
        var self1 = this;
        IVsemRII.onclick = function () {
            self1.crtajRIIsemestarIV();
        }

        var VsemRII = document.getElementById("semestar5RII");
        var self2 = this;
        VsemRII.onclick = function () {
            self2.crtajRIIsemestarV();
        }

        var VIsemRII = document.getElementById("semestar6RII");
        var self3 = this;
        VIsemRII.onclick = function () {
            self3.crtajRIIsemestarVI();
        }


        var VIIsemRII = document.getElementById("semestar7RII");
        var self4 = this;
        VIIsemRII.onclick = function () {
            self4.crtajRIIsemestarVII();
        }

        var VIIIsemRII = document.getElementById("semestar8RII");
        var self5 = this;
        VIIIsemRII.onclick = function () {
            self5.crtajRIIsemestarVIII();
        }

        var IIIsemEKM=document.getElementById("semestar3EKM");
        var self6=this;
        IIIsemEKM.onclick=function()
        {
            self6.crtajEKMsemestarIII();   
        }

        var IVsemEKM=document.getElementById("semestar4EKM");
        var self7=this;
        IVsemEKM.onclick=function()
        {
            self7.crtajEKMsemestarIV();   
        }
        
        var VsemEKM=document.getElementById("semestar5EKM");
        var self8=this;
        VsemEKM.onclick=function()
        {
            self8.crtajEKMsemestarV();   
        }

        var VIsemEKM=document.getElementById("semestar6EKM");
        var self9=this;
        VIsemEKM.onclick=function()
        {
            self9.crtajEKMsemestarVI();   
        }

        var VIIsemEKM=document.getElementById("semestar7EKM");
        var self10=this;
        VIIsemEKM.onclick=function()
        {
            self10.crtajEKMsemestarVII();   
        }

        var VIIIsemEKM=document.getElementById("semestar8EKM");
        var self11=this;
        VIIIsemEKM.onclick=function()
        {
            self11.crtajEKMsemestarVIII();   
        }

        



    }

    this.crtajIsem = function () {
        if (document.getElementById("I") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "I"
        for (var i = 0; i < this.Isemestar.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "I" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.Isemestar[i];
            list.appendChild(link);
            ul.appendChild(list);
            //  var separator = document.createElement("li");
            //  separator.className = "divider";
            //  ul.appendChild(separator);
        }
        referenca.appendChild(ul);
    }

    this.crtajIIsem = function () {
        if (document.getElementById("II") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "II"
        for (var i = 0; i < this.IIsemestar.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "II" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.IIsemestar[i];
            list.appendChild(link);
            ul.appendChild(list);
            //  var separator = document.createElement("li");
            //  separator.className = "divider";
            //  ul.appendChild(separator);
        }
        referenca.appendChild(ul);
    }

    this.crtajRIIsemestarIII=function()
    {
        if (document.getElementById("RII3") != null)
        {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id="RII3"
        for (var i=0; i<this.IIIsemestarRII.length; i++)
        {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII3" + i.toString();
            link.href = "diskusija";
            link.className="elementiListe"
            link.innerHTML = this.IIIsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
          //  var separator = document.createElement("li");
          //  separator.className = "divider";
          //  ul.appendChild(separator);
        }
        referenca.appendChild(ul);
    }

    this.crtajRIIsemestarIV = function () {
        if (document.getElementById("RII4") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }


        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "RII4"
        for (var i = 0; i < this.IVsemestarRII.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII4" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"

            link.innerHTML = this.IVsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
           // var separator = document.createElement("li");
           // separator.className = "divider";
            //ul.appendChild(separator);
        }
        referenca.appendChild(ul);
    }

    this.crtajRIIsemestarV = function () {
        if (document.getElementById("RII5") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }


        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "RII5"
        for (var i = 0; i < this.VsemestarRII.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII5" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"

            link.innerHTML = this.VsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }

    this.crtajRIIsemestarVI = function () {
        if (document.getElementById("RII6") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }


        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "RII6"
        for (var i = 0; i < this.VIsemestarRII.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII6" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"

            link.innerHTML = this.VIsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }
    
    this.crtajRIIsemestarVII = function () {
        if (document.getElementById("RII7") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }


        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "RII7"
        for (var i = 0; i < this.VIIsemestarRII.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII7" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"

            link.innerHTML = this.VIIsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
         }
        referenca.appendChild(ul);
    }

    this.crtajRIIsemestarVIII = function () {
        if (document.getElementById("RII8") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }


        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "RII8"
        for (var i = 0; i < this.VIIIsemestarRII.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "RII8" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"

            link.innerHTML = this.VIIIsemestarRII[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }

    this.crtajEKMsemestarIII=function()
    {
        if (document.getElementById("EKM3") != null)
        {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id="EKM3"
        for (var i=0; i<this.IIIsemestarEKM.length; i++)
        {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM3" + i.toString();
            link.href = "diskusija";
            link.className="elementiListe"
            link.innerHTML = this.IIIsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }

    this.crtajEKMsemestarIV = function () {
        if (document.getElementById("EKM4") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "EKM4"
        for (var i = 0; i < this.IVsemestarEKM.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM4" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.IVsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }
    
    this.crtajEKMsemestarV = function () {
        if (document.getElementById("EKM5") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "EKM5"
        for (var i = 0; i < this.VsemestarEKM.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM5" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.VsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }
    
    this.crtajEKMsemestarVI = function () {
        if (document.getElementById("EKM6") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "EKM6"
        for (var i = 0; i < this.VIsemestarEKM.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM6" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.VIsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }

    this.crtajEKMsemestarVII = function () {
        if (document.getElementById("EKM7") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "EKM7"
        for (var i = 0; i < this.VIIsemestarEKM.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM7" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.VIIsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }

    this.crtajEKMsemestarVIII = function () {
        if (document.getElementById("EKM8") != null) {
            return;
        }

        var deca = document.getElementById("informacijeOpredmetima");
        while (deca.firstChild) {
            deca.removeChild(deca.firstChild);
        }

        var referenca = document.getElementById("informacijeOpredmetima")
        var ul = document.createElement("ul");
        ul.className = "exams";
        ul.id = "EKM8"
        for (var i = 0; i < this.VIIIsemestarEKM.length; i++) {
            var list = document.createElement("li");
            var link = document.createElement("a");
            link.id = "EKM8" + i.toString();
            link.href = "diskusija";
            link.className = "elementiListe"
            link.innerHTML = this.VIIIsemestarEKM[i];
            list.appendChild(link);
            ul.appendChild(list);
        }
        referenca.appendChild(ul);
    }






}