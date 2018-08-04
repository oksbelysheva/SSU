import java.util.ArrayList;
import java.util.List;

/**
 * Created by oksbe on 13.05.2018.
 */
public class TestNash {
    ArrayList<ArrayList<Integer>> g;
    int timer;
    int[] tin, fup;
    boolean ExistBiconnectedComponent;

    public boolean testNash(ArrayList<ArrayList<Integer>> g) {
        this.g = g;
        if (!isConnectivity())
        {
            return false;
        }
        isExistBiconnectedComponent();
        if (ExistBiconnectedComponent)
        {
            return false;
        }
        int b = maximumIndependentSet(g).size();
        int d = minDegree(g);
        return (d >= Math.max(b, (g.size()+2)/3));
    }

    private int minDegree(ArrayList<ArrayList<Integer>> g){
        int min = 15;
        for (ArrayList<Integer> vertex:
             g) {
            if (vertex.size()<min)
                min = vertex.size();
        }
        return min;
    }

    private int dfs(int u, boolean[] visited){
        int visitedVertices = 1;
        visited[u] = true;
        for (int v:
             g.get(u)) {
            if (!visited[v])
            {
                visitedVertices += dfs(v, visited);
            }
        }
        return visitedVertices;
    }

    private boolean isConnectivity(){
        boolean[] visited = new boolean[g.size()];
        return  (dfs(0, visited)==g.size());
    }

    private boolean isExistBiconnectedComponent(){
        int timer = 0;
        boolean[] visited = new boolean[g.size()];
        tin = new int[g.size()];
        fup = new int[g.size()];
        ExistBiconnectedComponent = false;
        dfs2 (0,-1, visited);
        return false;
    }

    private void dfs2(int v, int p, boolean[] used){
        used[v] = true;
        tin[v] = fup[v] = timer++;
        int children = 0;
        for (int i=0; i < g.get(v).size(); ++i) {
            int to = g.get(v).get(i);
            if (to == p)  continue;
            if (used[to])
                fup[v] = Math.min(fup[v], tin[to]);
            else {
                dfs2(to, v, used);
                fup[v] = Math.min(fup[v], fup[to]);
                if (fup[to] >= tin[v] && p != -1)
                    ExistBiconnectedComponent = true;
                ++children;
            }
        }
        if (p == -1 && children > 1)
            ExistBiconnectedComponent = true;
    }

    private void findMaximumIndependentSet(List<Integer> cur, List<Integer> result, int[][] graph, int[] oldSet,
                                          int ne, int ce) {
        int nod = 0;
        int minnod = ce;
        int fixp = -1;
        int s = -1;
        for (int i = 0; i < ce && minnod != 0; i++) {
            int p = oldSet[i];
            int cnt = 0;
            int pos = -1;
            for (int j = ne; j < ce; j++)
                if (graph[p][oldSet[j]] == 1) {
                    if (++cnt == minnod)
                        break;
                    pos = j;
                }
            if (minnod > cnt) {
                minnod = cnt;
                fixp = p;
                if (i < ne) {
                    s = pos;
                } else {
                    s = i;
                    nod = 1;
                }
            }
        }
        int[] newSet = new int[ce];
        for (int k = minnod + nod; k >= 1; k--) {
            int sel = oldSet[s];
            oldSet[s] = oldSet[ne];
            oldSet[ne] = sel;
            int newne = 0;
            for (int i = 0; i < ne; i++)
                if (graph[sel][oldSet[i]] == 0)
                    newSet[newne++] = oldSet[i];
            int newce = newne;
            for (int i = ne + 1; i < ce; i++)
                if (graph[sel][oldSet[i]] == 0)
                    newSet[newce++] = oldSet[i];
            cur.add(sel);
            if (newce == 0) {
                if (result.size() < cur.size()) {
                    result.clear();
                    result.addAll(cur);
                }
            } else if (newne < newce) {
                if (cur.size() + newce - newne > result.size())
                    findMaximumIndependentSet(cur, result, graph, newSet, newne, newce);
            }
            cur.remove(cur.size() - 1);
            if (k > 1)
                for (s = ++ne; graph[fixp][oldSet[s]] == 0; s++)
                    ;
        }
    }
    private List<Integer> maximumIndependentSet(ArrayList<ArrayList<Integer>> g) {
        int n = g.size();
        int[][] graph = new int[n][n];
        for (int i = 0; i < g.size(); i++) {
            for (int j = 0; j < g.get(i).size(); j++) {
                graph[i][g.get(i).get(j)] = 1;
            }
        }
        int[] all = new int[n];
        for (int i = 0; i < n; i++)
            all[i] = i;
        List<Integer> res = new ArrayList<Integer>();
        findMaximumIndependentSet(new ArrayList<Integer>(), res, graph, all, 0, n);
        return res;
    }

}
