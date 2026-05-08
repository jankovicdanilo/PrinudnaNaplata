namespace PrinudnaNaplata.Models.Dtos.Case
{
    public record CaseFilterDto(
        // Quick search
        string? Sve,

        // Text filters
        string? BrojPartije,
        string? Ime,              // from Duznik
        string? ResenjeBroj,      // searches IVb, Pb, MalBroj, IpvBroj, RBroj too
        string? ZavedenKodPov,    // from Duznik
        string? Zaposlen,

        // FK lookups
        int? KlijentID,
        int? SudID,
        int? PravnoFizicko,       // from Duznik.PravnoLice

        // Amount thresholds
        decimal? UkupanDug,
        decimal? DugAdv,
        decimal? DugPov,
        decimal? FakturisanoProcenat,
        decimal? PlatioIznos,

        // Date ranges — Partija
        DateTime? PredatoDanaOd,
        DateTime? PredatoDanaDo,
        DateTime? DonetoDanaOd,
        DateTime? DonetoDanaDo,
        DateTime? IzvrsnoDanaOd,
        DateTime? IzvrsnoDanaDo,
        DateTime? OdlaganjeDo,
        DateTime? DatumProfaktureOd,
        DateTime? DatumProfaktureDo,
        DateTime? DatumFaktureOd,
        DateTime? DatumFaktureDo,

        // Bool filters from Partija (null = no filter)
        bool? Odlaganje,
        bool? Odbacen,
        bool? Prekinut,
        bool? Odbijen,
        bool? Obustavljen,
        bool? Storniran,
        bool? Fakturisano,
        bool? Fakturisati,
        bool? FakturisatiSaPDV,
        bool? NeFakturisati,
        bool? DodatnoFakturisati,
        bool? DostavaUredna,
        bool? PoslatNaBlagajnu,
        bool? Platio,
        bool? PlatioOsnovniDug,
        bool? Uplatio,
        bool? Prigovor,
        bool? PrigovorUsvojen,
        bool? PrigovorOdbijen,
        bool? PrigovorOdbacen,
        bool? Popis,
        bool? Procena,
        bool? Prodaja,
        bool? Zakljucena,
        bool? Mrtav,
        bool? Poravnanje,
        bool? IzvrsnoResenjeSuda,
        bool? PrvostepenaPresuda,
        bool? Zalba,
        bool? DrugostepenaPresuda,
        bool? IzvrsenjePoPresudi,
        bool? NemaPokretneImovine,
        bool? ZakljucakNalog,
        bool? ZakljucakNalogNisuPostupili,
        bool? PredlPokrImovina,
        bool? PredlNepokImovina,
        bool? JavnaObjava,
        bool? Hipoteka,

        // Bool filters from Duznik
        bool? Penzioner,
        bool? Nekretnina,
        bool? Vozila,

        int PageNumber = 1,
        int PageSize  = 10
    );
}