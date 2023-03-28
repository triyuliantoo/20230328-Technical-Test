using System;
using System.Data;
using System.Linq;

// Get the data from the database using your preferred data layer
var db = new MyDatabaseContext(); // replace with your own database context
var data = db.MSOccupation.ToList();

// Pivot the data using LINQ
var pivotedData = data.GroupBy(x => x.Occupation)
                      .Select(g => new
                      {
                          Occupation = g.Key,
                          Doctor = g.Where(x => x.Occupation == "Doctor").Select(x => x.Name).OrderBy(x => x).DefaultIfEmpty(null).ToList(),
                          Professor = g.Where(x => x.Occupation == "Professor").Select(x => x.Name).OrderBy(x => x).DefaultIfEmpty(null).ToList(),
                          Singer = g.Where(x => x.Occupation == "Singer").Select(x => x.Name).OrderBy(x => x).DefaultIfEmpty(null).ToList(),
                          Actor = g.Where(x => x.Occupation == "Actor").Select(x => x.Name).OrderBy(x => x).DefaultIfEmpty(null).ToList()
                      })
                      .OrderBy(x => x.Occupation);

// Create a DataTable and add the columns
var dataTable = new DataTable();
dataTable.Columns.Add("Doctor");
dataTable.Columns.Add("Professor");
dataTable.Columns.Add("Singer");
dataTable.Columns.Add("Actor");

// Add the rows to the DataTable
foreach (var row in pivotedData)
{
    var doctorList = row.Doctor != null ? string.Join(",", row.Doctor) : "NULL";
    var professorList = row.Professor != null ? string.Join(",", row.Professor) : "NULL";
    var singerList = row.Singer != null ? string.Join(",", row.Singer) : "NULL";
    var actorList = row.Actor != null ? string.Join(",", row.Actor) : "NULL";
    dataTable.Rows.Add(doctorList, professorList, singerList, actorList);
}

// Output the DataTable
foreach (DataRow row in dataTable.Rows)
{
    Console.WriteLine("{0}\t{1}\t{2}\t{3}", row["Doctor"], row["Professor"], row["Singer"], row["Actor"]);
}
