import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashSet;

/**
 * Created by oksbe on 01.03.2018.
 */
public class Main {
    public static void main(String[] args) throws IOException {
        FileWriter fileWriter = new FileWriter("temp.txt");
        String temp =  new String("YLSRZ");
        temp = temp.replaceFirst("S","BSCX");
        temp = temp.replaceFirst("S","BSCX");
        temp = temp.replaceFirst("S","BSCX");
        temp = temp.replaceFirst("S","BSCX");
        temp = temp.replaceFirst("S","BSCX");
        temp = temp.replaceFirst("S","");
        while (temp.contains("XC") || temp.contains("XR"))
        {
            temp = temp.replaceFirst("XC","CX");
            temp = temp.replaceFirst("XR","RX");
        }

        while (temp.contains("BC") || temp.contains("BA"))
        {
            temp = temp.replaceFirst("BC","CAB");
            temp = temp.replaceFirst("BA","AB");
        }

        while (temp.contains("LA") || temp.contains("LC"))
        {
            temp = temp.replaceFirst("LA","AL");
            temp = temp.replaceFirst("LC","L");
        }

        while (temp.contains("BR"))
            temp = temp.replaceFirst("BR","R");

        temp = temp.replaceFirst("LR","");


        while (temp.contains("AZ") || temp.contains("AX") || temp.contains("YX") || temp.contains("Ya") ||
        temp.contains("Aa"))
        {
            temp = temp.replaceFirst("AZ","Z");
            temp = temp.replaceFirst("AX","XaA");
            temp = temp.replaceFirst("YX","Y");
            temp = temp.replaceFirst("Ya","aY");
            temp = temp.replaceFirst("Aa","aA");
        }

        temp = temp.replaceFirst("YZ","");
        //fileWriter.write(tempString+" "+temp2+"\n");
        /*HashSet<String> set = new HashSet<>();
        HashSet<String> result = new HashSet<>();
        set.add(new String("YLSRZ"));
        while (true)
        {
            HashSet<String> tempSet = new HashSet<>(set);
            for (String tempString:
                    tempSet) {
                if (tempString.replace("a","").length()==0)
                {
                    System.out.println(tempString);
                    result.add(tempString);
                }
                String temp2 = tempString.replaceFirst("S","BSCX");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("S","");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("BC","CAB");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("BA","AB");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("LA","AL");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("LC","L");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("BR","R");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("LR","");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");

                temp2 = tempString.replaceFirst("XC","CX");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("XR","RX");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("AX","XaA");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("AZ","Z");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("YX","Y");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("Ya","aY");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
                temp2 = tempString.replaceFirst("YZ","");
                set.add(temp2);
                //fileWriter.write(tempString+" "+temp2+"\n");
            }
            if (set.contains("aaa"))
                break;
        }
        for (String te:
             result) {
            fileWriter.write(te+"\n");
        }*/

        fileWriter.write(Integer.toString(temp.length()));
        fileWriter.flush();
        fileWriter.close();
    }
}
