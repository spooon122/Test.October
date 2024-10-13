using System.Text;
using Test.October.Data.Models;

namespace Test.October.Services.Interfaces;

public interface IGraphService
{
    StringBuilder Graph(List<Trade> model);
}