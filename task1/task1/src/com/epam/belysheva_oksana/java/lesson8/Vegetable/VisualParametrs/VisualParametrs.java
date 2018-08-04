package com.epam.belysheva_oksana.java.lesson8.Vegetable.VisualParametrs;

/*
BelyshevaOA 531
lesson8
 */
public class VisualParametrs {
    protected Color color;
    protected Taste taste;

    public VisualParametrs() {
    }

    public VisualParametrs(Color color, Taste taste) {
        this.color = color;
        this.taste = taste;
    }

    public Color getColor() {
        return color;
    }

    public void setColor(Color value) {
        this.color = value;
    }

    public Taste getTaste() {
        return taste;
    }

    public void setTaste(Taste taste) {
        this.taste = taste;
    }

    public String toString() {
        return "VisualParameters{" +
                "color=" + color +
                ", taste=" + taste +
                '}';
    }
}
