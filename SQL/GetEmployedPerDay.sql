CREATE PROCEDURE GetEmployedPerDay(
	@from datetime = NULL,
	@until datetime = NULL
)
AS
BEGIN
	SELECT [date_employ], COUNT(date_employ)
	FROM dbo.persons WHERE
		(@from IS NULL OR [date_employ] >= @from) AND
		(@until IS NULL OR [date_employ] <= @until)
	GROUP BY [date_employ]
END