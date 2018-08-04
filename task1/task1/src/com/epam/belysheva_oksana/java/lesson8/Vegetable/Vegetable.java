package com.epam.belysheva_oksana.java.lesson8.Vegetable;

import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.VisualParametrs;

import java.io.Serializable;
import java.util.Set;

/*
BelyshevaOA 531
lesson8
 */
public interface Vegetable extends Comparable<Vegetable>, Serializable {
    public String getName();

    public VegetableType getType();

    public WayForEating getWayForEating();

    public Vitamins getVitamins();

    public VisualParametrs getVisualParemetrs();

    public double getWeight();

    public void setWeight(double weight);

    public NutritiveValue getNutritiveValue();

    public String toString();
}