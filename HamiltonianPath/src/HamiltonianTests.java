import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * Created by oksbe on 13.05.2018.
 */
public class HamiltonianTests {

    PrintWriter pw;

    public static void main(String[] args) throws FileNotFoundException {

        new HamiltonianTests().run();
    }

    public void run() throws FileNotFoundException {
        long startTime = System.currentTimeMillis();
        pw = new PrintWriter(new FileOutputStream("Result.txt"));
        PrintWriter pw1within2 = new PrintWriter(new FileOutputStream("Result1within2.txt"));
        PrintWriter pw2within1 = new PrintWriter(new FileOutputStream("Result2within1.txt"));
        PrintWriter pw12 = new PrintWriter(new FileOutputStream("Result12.txt"));
        System.out.println("Введите путь к входным данным:");
        Scanner pathScanner = new Scanner(System.in);
        String path = pathScanner.nextLine();
        Scanner scanner = new Scanner(new FileInputStream(path));

        int cnt1 = 0;
        int cnt2 = 0;
        int cnt12 = 0;

        while (scanner.hasNext()) {
            ArrayList<ArrayList<Integer>> g = readGraph(scanner);
            TestPosha testPosha = new TestPosha();
            TestNash testNash = new TestNash();

            if (g != null) {
                {
                    boolean t1 = testPosha.testPosha(g);
                    boolean t2 = testNash.testNash(g);



                    if (t1)
                        cnt1++;
                    if (t2)
                        cnt2++;
                    if (t1 && t2)
                        cnt12++;

                    if (t1 && !t2)
                    {
                        for (int i = 0; i < g.size(); i++) {
                            for (int j = 0; j < g.get(i).size(); j++)
                                pw1within2.println(i+" "+g.get(i).get(j));
                        }
                        pw1within2.println();
                    }

                    if (t2 && !t1)
                    {
                        for (int i = 0; i < g.size(); i++) {
                            for (int j = 0; j < g.get(i).size(); j++)
                                pw2within1.println(i+" "+g.get(i).get(j));
                        }
                        pw2within1.println();
                    }
                }
                }

        }

        pw.println("Тест Поша выполнился для " + cnt1 + "\n" +
                "тест Нэша-Вильямса выполнился для " + cnt2 + "\n" +
                "тесты Поша и Нэша-Вильямса выполняются одновременно для " + cnt12);
        System.out.println("Тест Поша выполнился " + cnt1 + "\n"+
        "тест Нэша-Вильямса выполнился для " + cnt2 + "\n" +
        "тесты Поша и Нэша-Вильямса выполняются одновременно для " + cnt12);

        long timeSpent = System.currentTimeMillis() - startTime;

        pw.println("Программа работала " + timeSpent + " ms");
        System.out.println("Программа работала " + timeSpent + " ms");

        pw.close();
        pw1within2.close();
        pw2within1.close();
        pw12.close();
    }

    public ArrayList<ArrayList<Integer>> readGraph(Scanner scanner) {
        while (scanner.hasNext())
        {
            String inputText = scanner.next();
            if (inputText.equals("Graph"))
            {
                ArrayList<ArrayList<Integer>> g = new ArrayList<>();
                String numberGraphPlus = scanner.next();
                numberGraphPlus = numberGraphPlus.substring(0, numberGraphPlus.length()-1);
                int numberGraph = Integer.parseInt(numberGraphPlus);
                //order
                scanner.next();
                String orderPlusPoint = scanner.next();
                int n = Integer.parseInt(orderPlusPoint.substring(0, orderPlusPoint.length()-1));
                //пустая строка
                scanner.nextLine();
                while (scanner.hasNextInt()) {
                    String vertexString = scanner.nextLine();
                    ArrayList<Integer> listVertex = new ArrayList<>();
                    vertexString = vertexString.substring(vertexString.indexOf(":")+1, vertexString.length()-1);
                    String[] splitVertexString = vertexString.trim().split(" ");
                    if (vertexString.trim().length()!=0)
                    {
                    for (String vertexNumber:
                         splitVertexString) {
                        listVertex.add(Integer.parseInt(vertexNumber));
                    }
                    }
                    g.add(listVertex);
                }
                return g;
            }
        }
        return null;
    }
}
