CREATE PROCEDURE GetCatalog AS
BEGIN
	SELECT [table]='status', * FROM dbo.status
	UNION
	SELECT [table]='deps', * FROM dbo.deps
	UNION
	SELECT [table]='posts', * FROM dbo.posts
END