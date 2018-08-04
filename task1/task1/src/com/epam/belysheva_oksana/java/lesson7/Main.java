package com.epam.belysheva_oksana.java.lesson7;

import com.epam.belysheva_oksana.java.lesson7.DAO.EmployeeDAO;
import com.epam.belysheva_oksana.java.lesson7.Entities.Employee;

import java.sql.Connection;
import java.util.List;
import java.util.Scanner;

/**
 * BelyshevaOA 531
 * lesson7
 * Для выполнения задания использована база данных MySQL
 */
public class Main {
    public static void main(String[] args) throws Exception {
        System.out.println("Enter command:\n" +
                "0-show all row\n" +
                "1-addEmployee(name,email,age)\n" +
                "2-get(index)\n" +
                "3-update(index,email)\n" +
                "4-deleteEmployee(index)\n" +
                "5-create 10 copies of each row\n" +
                "6-exit");
        Scanner scanner = new Scanner(System.in);
        int mode;
        Connection con = ConnectionFactory.process();
        EmployeeDAO empd = new EmployeeDAO(con);
        while (con != null && (mode = Integer.parseInt(scanner.next())) != 6) {
            switch (mode) {
                case 0: {
                    empd.showAllEmployee();
                    break;
                }
                case 1: {
                    System.out.println("Enter name:");
                    String name = scanner.next();
                    System.out.println("Enter email:");
                    String email = scanner.next();
                    System.out.println("Enter age:");
                    int age = Integer.parseInt(scanner.next());
                    empd.addEmployee(name, email, age);
                    break;
                }
                case 2: {
                    System.out.println("Enter id:");
                    int id = Integer.parseInt(scanner.next());
                    Employee employee = empd.getEmployee(id);
                    if (employee == null) {
                        System.out.println("Nor found");
                    } else {
                        System.out.println(employee.toString());
                    }
                    break;
                }
                case 3: {
                    System.out.println("Enter id:");
                    int id = Integer.parseInt(scanner.next());
                    System.out.println("Enter email:");
                    String email = scanner.next();
                    boolean resp = empd.updateEmail(id, email);
                    System.out.println(resp);
                    break;
                }
                case 4: {
                    System.out.println("Enter id:");
                    int id = Integer.parseInt(scanner.next());
                    System.out.println(empd.deleteEmployee(id));
                    break;
                }
                case 5: {
                    List<Employee> employeeList = empd.getAllEmployee();
                    for (Employee employee :
                            employeeList) {
                        for (int i = 0; i < 10; i++) {
                            empd.addEmployee(employee);
                        }
                    }
                }
            }
            System.out.println("Enter command:");
        }
        ConnectionFactory.closeConnection(con);
    }
}
