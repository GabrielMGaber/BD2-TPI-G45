USE TPI_Grupo45_Veterinaria;
GO

CREATE TRIGGER dbo.TR_DetalleConsulta_Stock_Insert
ON dbo.DetalleConsulta
AFTER INSERT AS BEGIN SET NOCOUNT ON;
	IF EXISTS(
		SELECT 1
		FROM dbo.Medicamentos AS m
		INNER JOIN(
			SELECT IdMedicamento, SUM(Cantidad) AS CantidadTotal
			 FROM inserted
            GROUP BY IdMedicamento
        ) AS i ON i.IdMedicamento = m.IdMedicamento
        WHERE m.Stock < i.CantidadTotal
    )
	BEGIN
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    UPDATE m
    SET m.Stock = m.Stock - i.CantidadTotal
    FROM dbo.Medicamentos AS m
    INNER JOIN
    (
        SELECT IdMedicamento, SUM(Cantidad) AS CantidadTotal
        FROM inserted
        GROUP BY IdMedicamento
    ) AS i ON i.IdMedicamento = m.IdMedicamento;
END;
GO

CREATE TRIGGER dbo.TR_DetalleConsulta_Stock_Delete
ON dbo.DetalleConsulta
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE m
    SET m.Stock = m.Stock + d.CantidadTotal
    FROM dbo.Medicamentos AS m
    INNER JOIN
    (
        SELECT IdMedicamento, SUM(Cantidad) AS CantidadTotal
        FROM deleted
        GROUP BY IdMedicamento
    ) AS d ON d.IdMedicamento = m.IdMedicamento;
END;
GO