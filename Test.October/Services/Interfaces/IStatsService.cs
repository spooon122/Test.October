using System.Text;
using Test.October.Data.Models;

namespace Test.October.Services.Interfaces;

public interface IStatsService
{
    StringBuilder GetStats(List<Trade> trades);
}