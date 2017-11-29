CREATE PROCEDURE KnjigaInsert
	@id_autor INT,
	@id_zanr INT,
	@naziv NVARCHAR(255),
	@slika NVARCHAR(255),
	@godina NVARCHAR(255),
	@opis NVARCHAR(255),
	@cena INT,
	@datum DATE,
	@last_one INT
	
	
AS
BEGIN
	SET NOCOUNT ON;
	SET @last_one = SCOPE_IDENTITY();

	INSERT INTO dbo.knjiga
		(id_autor, naziv, slika, godina, opis)
		VALUES (@id_autor, @naziv, @slika, @godina, @opis);

	INSERT INTO dbo.cena
		(id_knjiga,cena,datum)
		VALUES (@last_one,@cena,@datum);

	INSERT INTO dbo.zanrKnjiga
		(id_zanr,id_knjiga)
		VALUES (@id_zanr, @last_one);
END