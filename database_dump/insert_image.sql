update products set image =
(SELECT  BulkColumn FROM OPENROWSET(BULK  N'C:\Users\User\Desktop\GSFP\game\images\bg\forest_2.jpg', SINGLE_BLOB) AS x)
where id = 1