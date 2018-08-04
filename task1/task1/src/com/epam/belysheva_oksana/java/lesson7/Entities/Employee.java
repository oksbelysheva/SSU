package com.epam.belysheva_oksana.java.lesson7.Entities;

/**
 * BelyshevaOA 531
 * lesson7
 */
public class Employee {
    private int id;
    private String name;
    private String email;
    private int age;

    public Employee(int id, String name, String email, int age) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getEmail() {
        return email;
    }


    @Override
    public String toString() {
        return new String(getClass().getSimpleName() + "{id:" + id + ", name:" + name + ", age:" + age + ", email:"
                + email + "}");
    }
}
