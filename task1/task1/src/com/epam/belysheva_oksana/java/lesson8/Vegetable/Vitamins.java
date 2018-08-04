package com.epam.belysheva_oksana.java.lesson8.Vegetable;

import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.VisualParametrs;

/*
BelyshevaOA 531
lesson8
 */
public class Vitamins {
    private double A;
    private double A1;
    private double A2;
    private double B1;
    private double C;

    public Vitamins(double A, double A1, double A2, double B1, double C) {
        this.A = A;
        this.A1 = A1;
        this.A2 = A2;
        this.B1 = B1;
        this.C = C;
    }

    public String toString() {
        return "Vitamins{" +
                "A=" + A +
                ", A1=" + A1 +
                ", A2=" + A2 +
                ", B1=" + B1 +
                ", C=" + C +
                '}';
    }
}
