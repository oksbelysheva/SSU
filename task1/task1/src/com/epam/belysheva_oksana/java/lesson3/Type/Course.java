package com.epam.belysheva_oksana.java.lesson3.Type;

/**
 * BelyshevaOA 531
 * lesson 3
 */
public class Course {
    private String nameCourse;
    private int durationHours;

    public Course(String nameCourse, int durationHours) {
        this.nameCourse = nameCourse;
        this.durationHours = durationHours;
    }

    public Course(Course copyCourse) {
        this.nameCourse = copyCourse.nameCourse;
        this.durationHours = copyCourse.durationHours;
    }

    public String getNameCourse() {
        return nameCourse;
    }

    public void setNameCourse(String nameCourse) {
        this.nameCourse = nameCourse;
    }

    public int getDurationHours() {
        return durationHours;
    }

    public void setDurationHours(int durationHours) {
        this.durationHours = durationHours;
    }

    @Override
    public String toString() {
        return "Course [nameCourse=" + nameCourse + ", durationHours=" + durationHours + "]";
    }
}
