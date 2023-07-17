using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Custom/TerrainCustomTile")]
public class PathTile : RuleTile<PathTile.Neighbor> {
    public TileBase GrassTile;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Grass = 3;
        public const int Null = 4;
        public const int NotNull = 5;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Grass: return isPathTile(tile);
            case Neighbor.Null: return tile == null;
            case Neighbor.NotNull: return tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }

    private bool isPathTile(TileBase tile)
    {
        return tile ? tile.Equals(GrassTile) : false;
    }
}