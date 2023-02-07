
----------------------������� �1-----------------------------
--������� ��� ���������� �� ������� Sales.Customer 
-------------------------------------------------------------

SELECT *
FROM Sales.Customer

----------------------������� �2-----------------------------
--������� ��� ���������� �� ������� Sales.Store ��������������� 
--�� Name � ���������� �������
-------------------------------------------------------------

SELECT *
FROM Sales.Store
ORDER BY Sales.Store.Name 

----------------------������� �3-----------------------------
--������� �� ������� HumanResources.Employee ��� ����������
--� ������ �����������, ������� �������� ����� 1989-09-28
-------------------------------------------------------------

SELECT TOP 10 * 
FROM HumanResources.Employee 
WHERE BirthDate < '1989-09-28'

----------------------������� �4-----------------------------
--������� �� ������� HumanResources.Employee �����������
--� ������� ��������� ������ LoginID �������� 0.
--������� ������ NationalIDNumber, LoginID, JobTitle.
--������ ������ ���� ������������� �� JobTitle �� ��������
-------------------------------------------------------------

SELECT NationalIDNumber, LoginID, JobTitle
FROM HumanResources.Employee
WHERE LoginID LIKE '%0'
ORDER BY JobTitle DESC

----------------------������� �5-----------------------------
--������� �� ������� Person.Person ��� ���������� � �������, ������� ���� 
--��������� � 2008 ���� (ModifiedDate) � MiddleName ��������
--�������� � Title �� �������� �������� 
-------------------------------------------------------------

SELECT *
FROM Person.Person
WHERE ModifiedDate > '2007-12-31' AND ModifiedDate < '2009-01-01' AND MiddleName IS NOT NULL AND Title IS NULL

----------------------������� �6-----------------------------
--������� �������� ������ (HumanResources.Department.Name) ��� ����������
--� ������� ���� ����������
--������������ ������� HumanResources.EmployeeDepartmentHistory � HumanResources.Department
-------------------------------------------------------------

SELECT DISTINCT
d.Name
FROM HumanResources.Department d
JOIN HumanResources.EmployeeDepartmentHistory e ON d.DepartmentID = e.DepartmentID WHERE EndDate IS NULL --�� ���� ������������� ���� ���������� 

----------------------������� �7-----------------------------
--������������ ������ �� ������� Sales.SalesPerson �� TerritoryID
--� ������� ����� CommissionPct, ���� ��� ������ 0
-------------------------------------------------------------

SELECT *
FROM Sales.SalesPerson

SELECT Sum(CommissionPct) as ComissionPctSum
FROM Sales.SalesPerson 
GROUP BY TerritoryID HAVING Sum(CommissionPct) > 0

----------------------������� �8-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ����� ������� ���-�� 
--������� (HumanResources.Employee.VacationHours)
-------------------------------------------------------------

SELECT *
FROM HumanResources.Employee
WHERE VacationHours =
(
SELECT MAX(VacationHours)
FROM HumanResources.Employee
)

----------------------������� �9-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) 
--������� ����� ������� (HumanResources.Employee.JobTitle)
--'Sales Representative' ��� 'Network Administrator' ��� 'Network Manager'
-------------------------------------------------------------

SELECT *
FROM HumanResources.Employee
WHERE JobTitle = 'Sales Representative' OR JobTitle = 'Network Administrator' OR JobTitle = 'Network Manager' 

----------------------������� �10-----------------------------
--������� ��� ���������� � ����������� (HumanResources.Employee) � 
--�� ������� (Purchasing.PurchaseOrderHeader). ���� � ���������� ���
--������� �� ������ ���� ������� ����!!!
-------------------------------------------------------------

SELECT *
FROM HumanResources.Employee

SELECT *
FROM Purchasing.PurchaseOrderHeader

SELECT *
FROM HumanResources.Employee e
FULL JOIN Purchasing.PurchaseOrderHeader p ON e.BusinessEntityID = p.EmployeeID