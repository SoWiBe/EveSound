package com.example.MusicMicroservice.infrastructure.models;

public class Genre {
    String id;
    String name;
    public Genre(){}

    public Genre(String name, String id) {
        this.name = name;
        this.id = id;
    }

    public Genre(String name) {
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
