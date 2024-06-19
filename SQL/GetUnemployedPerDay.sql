CREATE PROCEDURE GetUnemployedPerDay(
	@from datetime = NULL,
	@until datetime = NULL
)
AS
BEGIN
	SELECT [date_uneploy], COUNT(date_uneploy)
	FROM dbo.persons WHERE
		(@from IS NULL OR [date_uneploy] >= @from) AND
		(@until IS NULL OR [date_uneploy] <= @until)
	GROUP BY [date_uneploy]
END