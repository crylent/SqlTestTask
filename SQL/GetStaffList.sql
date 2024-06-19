CREATE PROCEDURE GetStaffList(
	@last_name varchar(100) = NULL,
	@status int = NULL,
	@dep int = NULL,
	@post int = NULL,
	@employed_from datetime = NULL,
	@employed_until datetime = NULL,
	@unemployed_from datetime = NULL,
	@unemployed_until datetime = NULL
)
AS
BEGIN
	SELECT
		[name] = CONCAT(last_name, ' ', LEFT(first_name, 1), '. ', LEFT(second_name, 1), '.'),
		[status] = (SELECT [name] FROM dbo.status WHERE id=[status]),
		[dep] = (SELECT [name] FROM dbo.deps WHERE id=[id_dep]), 
		[post] = (SELECT [name] FROM dbo.posts WHERE id=[id_post]),
		[date_employ],
		[date_unemploy]=[date_uneploy]
	FROM dbo.persons WHERE
		(@last_name IS NULL OR [last_name] LIKE '%' + @last_name + '%')
		AND (@status IS NULL OR @status = [status])
		AND (@dep IS NULL OR @dep = [id_dep])
		AND (@post IS NULL OR @post = [id_post])
		AND (@employed_from IS NULL OR [date_employ] >= @employed_from)
		AND (@employed_until IS NULL OR [date_employ] <= @employed_until)
		AND (@unemployed_from IS NULL OR [date_uneploy] >= @unemployed_from)
		AND (@unemployed_until IS NULL OR [date_uneploy] <= @unemployed_until)
END