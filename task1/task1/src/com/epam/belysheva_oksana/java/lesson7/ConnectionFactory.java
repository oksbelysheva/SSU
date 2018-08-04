package com.epam.belysheva_oksana.java.lesson7;

import java.io.FileInputStream;
import java.sql.*;
import java.util.Properties;

/**
 * BelyshevaOA 531
 * lesson7
 */

public class ConnectionFactory {
    private static Properties dbProperties;
    private static String url;
    private static Driver dbDriver;

    static {
        try {
            dbProperties = new Properties();
            dbProperties.load(new FileInputStream("jdbc.properties"));
            //Загружает свойства (например key=value) из jdbc.properties файла текущей рабочей директории
            dbDriver = (Driver) Class.forName(dbProperties.getProperty("DriverClassName")).newInstance();
            url = dbProperties.getProperty("url"); //Возвращает url и null если не найдено
            if (url.equals(""))
                throw new Exception();
        } catch (Exception e) {
            System.out.println("Error jdbc.properties");
        }
    }

    //Если соединение успешно установлено то возвращает соедиенение, иначе ошибку
    public static Connection process() {
        try {
            if (url.equals(""))
                throw new SQLException();
            Connection connection = dbDriver.connect(url, dbProperties);
            System.out.println("The connection is established");
            return connection;
        } catch (SQLException e) {
            System.out.println("Connection error");
            return null;
        }
    }

    public static void closeConnection(Connection con) throws Exception {
        if (con != null)
            con.close();
        System.out.println("The connection is closed");
    }
}
