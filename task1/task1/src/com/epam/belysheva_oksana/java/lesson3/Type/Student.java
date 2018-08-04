package com.epam.belysheva_oksana.java.lesson3.Type;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * BelyshevaOA 531
 * lesson 3
 */
public class Student {
    private String nameStudent;
    private Curriculum curriculumStudend;
    private Date startDate;
    private int amountWorkHours;
    private int passedDays;
    private int passedHours;
    private Date currentDate;
    private Date currentHour;

    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd.MM.yyyy");
    SimpleDateFormat simpleHourFormat = new SimpleDateFormat("HH");

    public Student(String nameStudent, Curriculum curriculumStudend, Date startDate) {
        this.nameStudent = nameStudent;
        this.curriculumStudend = curriculumStudend;
        this.startDate = startDate;
        calculatePassed();
    }

    public String getNameStudent() {
        return nameStudent;
    }

    public void setNameStudent(String nameStudent) {
        this.nameStudent = nameStudent;
    }

    public Curriculum getCurriculumStudend() {
        return curriculumStudend;
    }

    public void setCurriculumStudend(Curriculum curriculumStudend) {
        this.curriculumStudend = curriculumStudend;
    }

    public Date getStartDate() {
        return startDate;
    }

    /*daysOfCourse = amountWorkHours / 8
     так как в дне 8 рабочих часов
     daysOfCourse = amountWorkHours % 8
     часы которые переходят на следующий день
     */
    public void calculatePassed() {
        currentDate = new Date();
        currentHour = new Date();
        simpleDateFormat.format(currentDate);
        simpleHourFormat.format(currentHour);
        amountWorkHours = curriculumStudend.getSumHours();

        int daysOfCourse = amountWorkHours / 8;
        int hoursOfCourse = amountWorkHours % 8;

        long differenceBetweenDates = currentDate.getTime() - startDate.getTime();
        this.passedDays = (int) (differenceBetweenDates / (24 * 60 * 60 * 1000));
        this.passedHours = Integer.parseInt(simpleHourFormat.format(currentHour));
    }

    public void setStartDate(Date startDate) {
        this.startDate = startDate;
    }

    /*daysOfCourse = amountWorkHours / 8
     так как в дне 8 рабочих часов
     daysOfCourse = amountWorkHours % 8
     часы которые переходят на следующий день
     */
    //отчет о том закончены курсы или нет
    public void isFinishStudy() {
        if (passedDays > amountWorkHours / 8 || (passedDays == amountWorkHours / 8 && passedHours >= amountWorkHours % 8 + 10)) {
            System.out.println("Studying completed");
        } else {
            System.out.println("Studying don't completed");
        }
    }

    /*daysOfCourse = amountWorkHours / 8
     так как в дне 8 рабочих часов
     daysOfCourse = amountWorkHours % 8
     часы которые переходят на следующий день
     */
    //отчет о том когда закончится практика или как давно она закончилась
    public void amountDayAndHours() {
        System.out.println("During courses - " + amountWorkHours + " h");
        System.out.println("Date of start: " + simpleDateFormat.format(startDate));

        Calendar calendar = Calendar.getInstance();
        calendar.setTime(startDate);
        int addDays = amountWorkHours / 8;
        if (amountWorkHours % 8 != 0)
            addDays++;
        calendar.add(Calendar.DAY_OF_MONTH, addDays - 1);
        Date finishDate = calendar.getTime();
        System.out.println("Date of finish: " + simpleDateFormat.format(finishDate));

        if (passedDays > amountWorkHours / 8 || (passedDays == amountWorkHours / 8 && Integer.parseInt(String.valueOf(currentHour)) >= amountWorkHours % 8 + 10)) {
            int laterDays = passedDays - amountWorkHours / 8;
            int laterHours = Math.min(18, passedHours) - (amountWorkHours % 8 + 10);
            System.out.print("After the finish ");
            System.out.print(laterDays + " day ");
            System.out.println(laterHours + " h" + "\n");
        } else {
            int leftDays = amountWorkHours / 8 - passedDays;
            if (passedHours >= 18) {
                leftDays--;
            }
            int leftHours = (amountWorkHours % 8 + 10) - Math.min(10, Math.max(10, passedHours));
            System.out.print("Before th finish ");
            System.out.print(leftDays + " day ");
            System.out.println(leftHours + " h" + "\n");
        }
    }

}
