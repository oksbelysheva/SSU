package com.epam.belysheva_oksana.java.lesson8.XML;

import com.epam.belysheva_oksana.java.lesson8.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.*;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.TypeVegetable.*;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.Color;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.Taste;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.VisualParametrs;
import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;

/*
BelyshevaOA 531
lesson8
 */
public class XMLHelper {
    private static XMLHelper currentInstance = new XMLHelper();

    public static XMLHelper getInstance() {
        return currentInstance;
    }

    public XMLHelper() {
    }

    public boolean vegetableWriteToXML(final Vegetable vegetable, String nameOfFile) {
        XStream xs = new XStream(new DomDriver());
        xs.alias("vegetable", Beans.class);
        xs.alias("vegetable", Bulbous.class);
        xs.alias("vegetable", Cauline.class);
        xs.alias("vegetable", Root.class);
        xs.alias("vegetable", Tuberous.class);
        xs.alias("vegetable", Vegetable.class);

        try {
            FileOutputStream fs = new FileOutputStream(nameOfFile);
            xs.toXML(vegetable, fs);
        } catch (FileNotFoundException e) {
            System.out.println(e.getMessage());
            return false;
        }

        System.out.println("Vegetable has been serialized to XML " + nameOfFile);
        return true;
    }

    public static Vegetable getNewVegetable(String pathname) throws Exception {
        try {
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            documentBuilderFactory.setValidating(false);
            DocumentBuilder builder = documentBuilderFactory.newDocumentBuilder();
            Document document = builder.parse(new File(pathname));
            document.getDocumentElement().normalize();

            return parseDocument(document);
        } catch (Exception exception) {
            String message = "XML parsing error!";
            throw new Exception(message);
        }
    }

    private static Vegetable parseDocument(Document doc) throws InvalidVegetableCharacteristicException {
        Node vegetable = doc.getElementsByTagName("vegetable").item(0);

        String type = getType(vegetable);
        String name = getName(vegetable);
        WayForEating wayForEatin = getWayForEating(vegetable);

        VisualParametrs visualParametrs;
        NutritiveValue nutritiveValue;
        Vitamins vitamins;

        try {
            if (vegetable.getNodeType() == Node.ELEMENT_NODE) {
                Element element = (Element) vegetable;
                Node parameters = element.getElementsByTagName("visualParametrs").item(0);
                visualParametrs = parseVisualParameters(parameters);
                parameters = element.getElementsByTagName("nutritiveValue").item(0);
                nutritiveValue = parseNutritiveValue(parameters);
                parameters = element.getElementsByTagName("vitamins").item(0);
                vitamins = parseVitamins(parameters);
                switch (type) {
                    case "BEANS": {
                        return new Beans(name, nutritiveValue, wayForEatin, vitamins, visualParametrs);
                    }
                    case "ROOT": {
                        return new Root(name, nutritiveValue, wayForEatin, vitamins, visualParametrs);
                    }
                    case "CAULINE": {
                        return new Cauline(name, nutritiveValue, wayForEatin, vitamins, visualParametrs);
                    }
                    case "TUBEROUS": {
                        return new Tuberous(name, nutritiveValue, wayForEatin, vitamins, visualParametrs);
                    }
                    case "BULBOUS": {
                        return new Bulbous(name, nutritiveValue, wayForEatin, vitamins, visualParametrs);
                    }
                }

            }
        } catch (InvalidVegetableCharacteristicException e) {
            throw new InvalidVegetableCharacteristicException("Error reading parameters");
        }
        return null;
    }

    private static WayForEating getWayForEating(Node node) throws InvalidVegetableCharacteristicException {
        Element parameters = (Element) node;

        String wayForEatingString = parameters.getElementsByTagName("wayForEating").item(0).getTextContent();
        WayForEating wayForEating = WayForEating.UNDERFINED;

        switch (wayForEatingString) {
            case "BOIL": {
                wayForEating = WayForEating.BOIL;
                break;
            }
            case "FRESH": {
                wayForEating = WayForEating.FRESH;
                break;
            }
            case "DRY": {
                wayForEating = WayForEating.DRY;
                break;
            }
            case "FRY": {
                wayForEating = WayForEating.FRY;
                break;
            }
        }

        if (wayForEating == WayForEating.UNDERFINED)
            throw new InvalidVegetableCharacteristicException("Error reading parameters");

        return wayForEating;
    }

    private static Vitamins parseVitamins(Node node) throws InvalidVegetableCharacteristicException {
        Element parameters = (Element) node;

        String A = parameters.getElementsByTagName("A").item(0).getTextContent();
        String A1 = parameters.getElementsByTagName("A1").item(0).getTextContent();
        String A2 = parameters.getElementsByTagName("A2").item(0).getTextContent();
        String B1 = parameters.getElementsByTagName("B1").item(0).getTextContent();
        String C = parameters.getElementsByTagName("C").item(0).getTextContent();

        return new Vitamins(Double.parseDouble(A), Double.parseDouble(A1), Double.parseDouble(A2), Double.parseDouble(B1), Double.parseDouble(C));
    }


    private static NutritiveValue parseNutritiveValue(Node node) throws InvalidVegetableCharacteristicException {
        Element parameters = (Element) node;

        String calories = parameters.getElementsByTagName("calories").item(0).getTextContent();
        String carbohydrates = parameters.getElementsByTagName("carbohydrates").item(0).getTextContent();
        String protein = parameters.getElementsByTagName("protein").item(0).getTextContent();

        return new NutritiveValue(Double.parseDouble(calories), Double.parseDouble(carbohydrates), Double.parseDouble(protein));
    }

    private static VisualParametrs parseVisualParameters(Node node) throws InvalidVegetableCharacteristicException {
        Element parameters = (Element) node;

        String color = parameters.getElementsByTagName("color").item(0).getTextContent();
        String taste = parameters.getElementsByTagName("taste").item(0).getTextContent();
        Color readColor = Color.UNDERFINED;
        Taste readTaste = Taste.UNDERFINED;

        switch (color) {
            case "YELLOW": {
                readColor = Color.YELLOW;
                break;
            }
            case "RED": {
                readColor = Color.RED;
                break;
            }
            case "ORANGE": {
                readColor = Color.ORANGE;
                break;
            }
            case "GREEN": {
                readColor = Color.GREEN;
                break;
            }
        }

        switch (taste) {
            case "SWEET": {
                readTaste = Taste.SWEET;
                break;
            }
            case "BITTER": {
                readTaste = Taste.BITTER;
                break;
            }
        }

        if (readColor == Color.UNDERFINED || readTaste == Taste.UNDERFINED)
            throw new InvalidVegetableCharacteristicException("Error reading visual parameters");

        return new VisualParametrs(readColor, readTaste);
    }

    private static double getWeight(Node node) {
        Element vegetable = (Element) node;
        Node name = vegetable.getElementsByTagName("weight").item(0).getFirstChild();

        return Double.parseDouble(name.getTextContent());
    }

    private static String getName(Node node) {
        Element vegetable = (Element) node;
        Node name = vegetable.getElementsByTagName("name").item(0);

        return name.getTextContent();
    }

    private static String getType(Node node) {
        Element vegetable = (Element) node;
        Node type = vegetable.getElementsByTagName("type").item(0);

        return type.getTextContent();
    }
}
