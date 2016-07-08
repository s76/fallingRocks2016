using UnityEngine;

namespace Core.Model
{
    public interface ICellEntity
    {
        int IndexX { get; }
        int IndexZ { get; }
        int IndexH { get; }
    }
}
