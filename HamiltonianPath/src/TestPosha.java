import java.util.ArrayList;
import java.util.Arrays;

public class TestPosha {
    public boolean testPosha(ArrayList<ArrayList<Integer>> g) {
        int n = g.size();
        if (n < 3)
            return false;


        for (int k = 1; k < (double)(n-1)/2; k++) {
            if (f(k, g)>=k)
                return false;
        }

        if (n % 2 != 0)
        {
            if (f((n-1)/2,g)>(n-1)/2)
                return false;
        }

        return true;
    }

    private int f (int x, ArrayList<ArrayList<Integer>> g){
        int result = 0;
        for (ArrayList<Integer> vertexList:
                g) {
            if (vertexList.size()<=x)
                result++;
        }
        return result;
    }
}
