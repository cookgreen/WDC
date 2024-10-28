using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Xml;

namespace WDC.Game
{
    public class SpriteAStarMovement : SpriteMovement
    {
        private PointF startPos;
        private List<GameMapAIMeshBlock> aIMeshPoints;
        private List<GameMapAIMeshBlock> path;

        public override event Action DestReached;
        private int initDelayTime;
        private int currDelayTime;

        public SpriteAStarMovement(PointF startPos, PointF destPos, List<GameMapAIMeshBlock> aIMeshPoints, int collideCheckTolerance) : base(collideCheckTolerance)
        {
            this.startPos = startPos;
            this.destPosition = destPos;
            this.aIMeshPoints = aIMeshPoints;
            initDelayTime = 5;
            currDelayTime = initDelayTime;

            path = searchPath();
        }

        private List<GameMapAIMeshBlock> searchPath()
        {
            List<GameMapAIMeshBlock> openList = new List<GameMapAIMeshBlock>();
            List<GameMapAIMeshBlock> closeList = new List<GameMapAIMeshBlock>();

            GameMapAIMeshBlock startNode = null;
            foreach(var point in aIMeshPoints)
            {
                if (point.ContainsLocF(startPos))
                {
                    startNode = point; 
                    break;
                }
            }

            GameMapAIMeshBlock endNode = null;
            foreach (var point in aIMeshPoints)
            {
                if (point.ContainsLocF(destPosition))
                {
                    endNode = point;
                    break;
                }
            }

            openList.Clear();
            closeList.Clear();

            openList.Add(startNode);

            GameMapAIMeshBlock curNode;
            while (openList.Count > 0)
            {
                curNode = openList[0];
                for (int i = 0; i < openList.Count; i++)
                {
                    if (openList[i].CostF < curNode.CostF && openList[i].CostH < curNode.CostH)
                    {
                        curNode = openList[i];
                    }
                }

                openList.Remove(curNode);
                closeList.Add(curNode);

                //if (curNode.Equals(endNode)) 
                //{  
                //    return GetPathWithNode(startNode, endNode); 
                //} 

                var aroundNodes = curNode.GetNearbyBlocks(aIMeshPoints);
                for (int i = 0; i < aroundNodes.Count; i++)
                {
                    if (aroundNodes[i].Equals(endNode))
                    {
                        aroundNodes[i].LastNode = curNode;
                        return GetPathWithNode(startNode, endNode);
                    }

                    if (!aroundNodes[i].IsWall && !closeList.Contains(aroundNodes[i]))
                    {
                        int newCostG = curNode.CostG + GetNodesDistance(curNode, aroundNodes[i]);

                        if (newCostG <= aroundNodes[i].CostG || !openList.Contains(aroundNodes[i]))
                        {
                            aroundNodes[i].CostG = newCostG;
                            aroundNodes[i].CostH = GetNodesDistance(aroundNodes[i], endNode);
                            aroundNodes[i].LastNode = curNode;
                            if (!openList.Contains(aroundNodes[i]))
                            {
                                openList.Add(aroundNodes[i]);
                            }
                        }
                    }
                }
            }
            return null;
        }

        private int GetNodesDistance(GameMapAIMeshBlock startNode, GameMapAIMeshBlock endNode)
        {
            return Math.Abs(startNode.WPos.X - endNode.WPos.X) + Math.Abs(startNode.WPos.Y - endNode.WPos.Y);
        }

        private List<GameMapAIMeshBlock> GetPathWithNode(GameMapAIMeshBlock startNode, GameMapAIMeshBlock endNode)
        {
            List<GameMapAIMeshBlock> tmpNodePath = new List<GameMapAIMeshBlock>();
            if (endNode != null)
            {
                GameMapAIMeshBlock temp = endNode;
                while (temp != startNode)
                {
                    tmpNodePath.Add(temp);
                    temp = temp.LastNode;
                }
                tmpNodePath.Add(startNode);
            }
            return tmpNodePath;
        }

        public override PointF GetNext()
        {
            Point wpos = path.Last().WPos;

            if (currDelayTime == 0)
            {
                path.RemoveAt(path.Count - 1);
                currDelayTime = initDelayTime;
            }
            else
            {
                currDelayTime--;
            }

            return wpos;
        }

        public override void CheckDestReached()
        {
            if (path.Count == 0)
            {
                DestReached?.Invoke();
            }
        }
    }
}
