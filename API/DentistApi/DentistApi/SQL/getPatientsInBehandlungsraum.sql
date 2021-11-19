Select "User"."Id" as "UserId", "Termin"."Raum" from "User"
    JOIN "Termin" On "User"."Id" = "Termin"."UserId"
    where "Status" = 'inBehandlung' And DATE("Datum") = CURRENT_DATE