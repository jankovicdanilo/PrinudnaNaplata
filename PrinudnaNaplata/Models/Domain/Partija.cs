using System.ComponentModel.DataAnnotations.Schema;

namespace PrinudnaNaplata.Domain;

public class Partija
{
    public long PartijaID { get; set; }
    public int DuznikID { get; set; }
    public int KlijentID { get; set; }
    public long? SudID { get; set; }
    public long? Sud1ID { get; set; }

    // Brojevi predmeta
    public string? BrojPartije { get; set; }
    public string? ResenjeBroj { get; set; }
    public string? IVb { get; set; }
    public string? Pb { get; set; }
    public string? MalBroj { get; set; }
    public string? IpvBroj { get; set; }
    public string? RBroj { get; set; }
    public string? SpojenUIBroj { get; set; }

    // Iznosi duga
    public DateTime? DugOd { get; set; }
    public DateTime? DugDo { get; set; }
    public decimal? IznosDuga { get; set; }
    public decimal? AdvTarifa { get; set; }
    public decimal? SudskeTakse { get; set; }
    public decimal? TrenutniDug { get; set; }
    public decimal? PlatioIznos { get; set; }
    public decimal? IznosPoPrigovoru { get; set; }
    public decimal? ATPoPrigovoru { get; set; }
    public decimal? TaksaPoPrigovoru { get; set; }
    public decimal? DodatniAT { get; set; }
    public decimal? ProcenatUspjeha { get; set; }
    public decimal? FakturisanoProcenat { get; set; }

    // Datumi
    public DateTime? PredatoDana { get; set; }
    public DateTime? DonetoDana { get; set; }
    public DateTime? PrimioDana { get; set; }
    public DateTime? IzvrsnoDana { get; set; }
    public DateTime? OdlaganjeDo { get; set; }
    public DateTime? IzvrsnoResenjeDatum { get; set; }
    public DateTime? PoravnanjeDatum { get; set; }
    public DateTime? PresudaDatum { get; set; }
    public DateTime? PrvostepenaPresudaDatum { get; set; }
    public DateTime? DrugostepenaPresudaDatum { get; set; }
    public DateTime? HipotekaDatum { get; set; }
    public DateTime? PredlPokrImPredDana { get; set; }
    public DateTime? PredlPokrImDonDana { get; set; }
    public DateTime? PredlNepImPredDana { get; set; }
    public DateTime? PredlNepImDonDana { get; set; }

    // Status zastavice
    public bool Platio { get; set; }
    public bool Obustavljen { get; set; }
    public bool Storniran { get; set; }
    public bool Fakturisano { get; set; }
    public bool DostavaUredna { get; set; }
    public bool PoslatNaBlagajnu { get; set; }
    public bool PlatioOsnovniDug { get; set; }
    public bool Prigovor { get; set; }
    public bool PrigovorUsvojen { get; set; }
    public bool PrigovorOdbijen { get; set; }
    public bool PrigovorOdbacen { get; set; }
    public bool Popis { get; set; }
    public bool Procena { get; set; }
    public bool Prodaja { get; set; }
    public bool Zakljucena { get; set; }
    public bool Odlaganje { get; set; }
    public bool Odbacen { get; set; }
    public bool Prekinut { get; set; }
    public bool Odbijen { get; set; }
    public bool Fakturisati { get; set; }
    public bool FakturisatiSaPDV { get; set; }
    public bool NeFakturisati { get; set; }
    public bool IzvrsnoResenjeSuda { get; set; }
    public bool Poravnanje { get; set; }
    public bool PrvostepenaPresuda { get; set; }
    public bool Zalba { get; set; }
    public bool DrugostepenaPresuda { get; set; }
    public bool IzvrsenjePoPresudi { get; set; }
    public bool Uplatio { get; set; }
    public bool NemaPokretneImovine { get; set; }
    public bool ZakljucakNalog { get; set; }
    public bool ZakljucakNalogNisuPostupili { get; set; }
    public bool Mrtav { get; set; }
    public bool PredlPokrImovina { get; set; }
    public bool PredlNepokImovina { get; set; }
    public bool DodatnoFakturisati { get; set; }
    public bool JavnaObjava { get; set; }
    public bool Hipoteka { get; set; }

    public string? Napomena { get; set; }

    [NotMapped]
    public string? DuznikIme { get; set; }
}
