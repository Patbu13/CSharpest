using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CSharpest.Classes;

//	Last modified by: David Eta
//	Windows Prog 547
//	Last Updated : 11/22/23

public class Bundle
{
    // fields
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Bundle(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}
