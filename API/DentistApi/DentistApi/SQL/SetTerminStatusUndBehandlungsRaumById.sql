update "Termin"
set "Status" = @status,
	"Raum" = @raum
where "Id" = @id;