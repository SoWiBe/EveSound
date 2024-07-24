package infrastructure.models;

import infrastructure.models.enums.PorodaType;
import infrastructure.models.enums.Sex;

/*
    Example for training
 */
public class Animal {
    private String id;
    private String type;
    String name;
    int age;
    String bolezni;
    PorodaType porodaType;
    Sex sexType;

    public Animal(String id, String type, String name, int age, String bolezni, PorodaType porodaType, Sex sexType) {
        this.id = id;
        this.type = type;
        this.name = name;
        this.age = age;
        this.bolezni = bolezni;
        this.porodaType = porodaType;
        this.sexType = sexType;
    }

    public Animal(Sex sexType, PorodaType porodaType, String bolezni, int age, String name, String type) {
        this.sexType = sexType;
        this.porodaType = porodaType;
        this.bolezni = bolezni;
        this.age = age;
        this.name = name;
        this.type = type;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getBolezni() {
        return bolezni;
    }

    public void setBolezni(String bolezni) {
        this.bolezni = bolezni;
    }

    public PorodaType getPorodaType() {
        return porodaType;
    }

    public void setPorodaType(PorodaType porodaType) {
        this.porodaType = porodaType;
    }

    public Sex getSexType() {
        return sexType;
    }

    public void setSexType(Sex sexType) {
        this.sexType = sexType;
    }
}

