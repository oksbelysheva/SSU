package com.epam.belysheva_oksana.java.lesson7.DAO;

import com.epam.belysheva_oksana.java.lesson7.DAO.Interfaces.EmployeeDAOI;
import com.epam.belysheva_oksana.java.lesson7.Entities.Employee;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

/**
 * BelyshevaOA 531
 * lesson7
 */
public class EmployeeDAO implements EmployeeDAOI {
    private Statement st = null;
    private Connection con = null;

    public EmployeeDAO(Connection con) {
        this.con = con;
    }

    @Override
    public boolean addEmployee(String name, String email, int age) throws SQLException {
        String sql = "insert into table_employee(name, age, email) values('" + name + "'," + age + ",'" + email + "');";
        try {
            st = con.createStatement();
            st.executeUpdate(sql);
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            if (!st.isClosed()) {
                st.close();
            }
        }
    }

    @Override
    public boolean addEmployee(Employee employee) throws SQLException {
        String name = employee.getName();
        String email = employee.getEmail();
        int age = employee.getAge();
        String sql = "insert into table_employee(name, age, email) values('" + name + "'," + age + ",'" + email + "');";
        try {
            st = con.createStatement();
            st.executeUpdate(sql);
            return true;
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        } finally {
            if (!st.isClosed()) {
                st.close();
            }
        }
    }

    @Override
    public boolean updateEmail(int id, String email) throws Exception {
        String sql = "update table_employee set email='" + email + "' where id=" + id;
        boolean flag = false;
        try {
            Statement st = con.createStatement();
            if (st.executeUpdate(sql) > 0) {
                flag = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (!st.isClosed()) {
                st.close();
            }
        }
        return flag;
    }

    //Возвращает Employee если найден с таким id и null иначе
    @Override
    public Employee getEmployee(int id) throws Exception {
        String sql = "select * from table_employee where id=" + id;
        StringBuilder sb = new StringBuilder();
        ResultSet rs = null;
        Employee employee = null;
        try {
            Statement st = con.createStatement();
            rs = st.executeQuery(sql);
            if (rs.next()) {
                employee = new Employee(rs.getInt("id"), rs.getString("name"),
                        rs.getString("email"), rs.getInt("age"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        } finally {
            if (!st.isClosed()) {
                st.close();
            }
            if (!rs.isClosed()) {
                rs.close();
            }
        }
        return employee;
    }

    @Override
    public boolean deleteEmployee(int id) throws Exception {
        String sql = "deleteEmployee from table_employee where id=" + id;
        boolean flag = false;
        try {
            Statement st = con.createStatement();
            if (st.executeUpdate(sql) > 0) {
                flag = true;
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (!st.isClosed()) {
                st.close();
            }
        }
        return flag;
    }

    @Override
    public void showAllEmployee() {
        try {
            Statement st = con.createStatement();
            ResultSet resultSet = st.executeQuery("select * from table_employee");

            while (resultSet.next()) {
                Employee employee = new Employee(resultSet.getInt("id"), resultSet.getString("name"),
                        resultSet.getString("email"), resultSet.getInt("age"));
                System.out.println(employee.toString());
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public List<Employee> getAllEmployee() {
        ArrayList<Employee> employeeArrayList = new ArrayList<>();
        try {
            Statement st = con.createStatement();
            ResultSet resultSet = st.executeQuery("select * from table_employee");

            while (resultSet.next()) {
                Employee employee = new Employee(resultSet.getInt("id"), resultSet.getString("name"),
                        resultSet.getString("email"), resultSet.getInt("age"));
                employeeArrayList.add(employee);
            }
            return employeeArrayList;
        } catch (SQLException e) {
            e.printStackTrace();
            return null;
        }
    }
}
