package com.epam.belysheva_oksana.java.lesson8.Vegetable.TypeVegetable;

import com.epam.belysheva_oksana.java.lesson8.Exception.InvalidVegetableCharacteristicException;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.*;
import com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs.VisualParametrs;

/*
BelyshevaOA 531
lesson8
 */
public class Root implements Vegetable {
    private VegetableType type = VegetableType.ROOT;

    private String name;
    private NutritiveValue nutritiveValue;
    private double weight = 100;
    private Vitamins vitamins;
    private WayForEating wayForEating;
    private VisualParametrs visualParametrs;

    public Root() {
    }

    public Root(String name, NutritiveValue nutritiveValue, WayForEating wayForEating, Vitamins vitamins, VisualParametrs visualParametrs) throws InvalidVegetableCharacteristicException {
        if (name.length() == 0 || name.replace(" ", "").length() == 0)
            throw new InvalidVegetableCharacteristicException("Cannot create vegeteble with name " + name);

        this.name = name;
        this.nutritiveValue = nutritiveValue;
        this.wayForEating = wayForEating;
        this.vitamins = vitamins;
        this.visualParametrs = visualParametrs;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getWeight() {
        return weight;
    }

    @Override
    public void setWeight(double weight) {
        this.weight = weight;
    }

    @Override
    public VegetableType getType() {
        return type;
    }

    @Override
    public WayForEating getWayForEating() {
        return wayForEating;
    }

    @Override
    public Vitamins getVitamins() {
        return vitamins;
    }

    @Override
    public VisualParametrs getVisualParemetrs() {
        return visualParametrs;
    }

    @Override
    public NutritiveValue getNutritiveValue() {
        return nutritiveValue;
    }

    @Override
    public int compareTo(Vegetable o) {
        if (this.getNutritiveValue().getCalories() > o.getNutritiveValue().getCalories()) {
            return 1;
        }

        if (this.getNutritiveValue().getCalories() < o.getNutritiveValue().getCalories()) {
            return -1;
        }

        return 0;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null || obj.getClass() != this.getClass()) {
            return false;
        }

        Beans o = (Beans) obj;

        return this.name.equals(o.getName()) && this.getNutritiveValue().getCalories() == o.getNutritiveValue().getCalories() &&
                this.getNutritiveValue().getProtein() == o.getNutritiveValue().getProtein()
                && this.getNutritiveValue().getCarbohydrates() == o.getNutritiveValue().getCarbohydrates();
    }

    @Override
    public String toString() {
        return (name + " : \n" + "category : " + type + "\n" + nutritiveValue.toString() + "\n"
                + visualParametrs.toString() + "\n" + "Way for eating: " + wayForEating + "\n" + vitamins + "\n");
    }
}
