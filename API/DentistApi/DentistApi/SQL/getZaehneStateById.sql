Select  z."Id", t."type", s."date", F."Position"
from "Zahn" z
    JOIN "Zahnstate" s ON z."ZahnstateID" = s."Id" OR z."ZahnstateID" = s."ParentZahnstate"
    Join "ZahnTask" t on t."Id" = s."ZahnTaskId"
    JOIN "Fuellung" F on s."ZahnTaskId" = F."ZahnTaskId"
WHERE z."Id" = @id;