package com.epam.belysheva_oksana.java.lesson6.Serialization;

import com.epam.belysheva_oksana.java.lesson6.VegetableSalad;

import java.io.*;

/*
BelyshevaOA 531
lesson6
 */
public class SerializationHelper {
    private static SerializationHelper currentInstance = new SerializationHelper();

    public static SerializationHelper getInstance() {
        return currentInstance;
    }

    public SerializationHelper() {
    }

    public boolean serializeVegetableSalad(final VegetableSalad vegetableSalad, String nameOfFile) {
        FileOutputStream fos = null;
        try {
            fos = new FileOutputStream("salad.out");
            ObjectOutputStream oos = new ObjectOutputStream(fos);
            oos.writeObject(vegetableSalad);
            oos.flush();
            oos.close();
            System.out.println("VegetableSalad has been serialized to " + nameOfFile);
            return true;
        } catch (FileNotFoundException e) {
            e.printStackTrace();
            return false;
        } catch (IOException e) {
            e.printStackTrace();
            return false;
        }
    }

    public VegetableSalad deserializeVegetableSalad(String nameOfFile) {
        FileInputStream fis = null;
        try {
            fis = new FileInputStream("salad.out");
            ObjectInputStream oin = new ObjectInputStream(fis);
            VegetableSalad salad = (VegetableSalad) oin.readObject();
            return salad;
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
        return null;
    }
}
