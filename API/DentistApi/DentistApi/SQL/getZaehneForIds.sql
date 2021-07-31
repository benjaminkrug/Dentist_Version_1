Select F."Id" from "Zahn" z
    JOIN "Zahnstate" s ON z."ZahnstateID" = s."Id" OR z."ZahnstateID" = s."ParentZahnstate"
    JOIN "Fuellung" F on s."ZahnTaskId" = F."ZahnTaskId"
WHERE z."Id" =@id;
