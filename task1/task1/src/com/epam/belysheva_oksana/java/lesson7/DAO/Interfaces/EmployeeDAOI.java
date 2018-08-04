package com.epam.belysheva_oksana.java.lesson7.DAO.Interfaces;

import com.epam.belysheva_oksana.java.lesson7.Entities.Employee;

import java.sql.SQLException;
import java.util.List;

/**
 * BelyshevaOA 531
 * lesson7
 */
public interface EmployeeDAOI {
    public boolean addEmployee(String name, String email, int age) throws Exception;

    boolean addEmployee(Employee employee) throws SQLException;

    public boolean updateEmail(int id, String email) throws Exception;

    public Employee getEmployee(int id) throws Exception;

    boolean deleteEmployee(int id) throws Exception;

    void showAllEmployee();

    List<Employee> getAllEmployee();
}
