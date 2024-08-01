package com.example.MusicMicroservice.infrastructure.models;

/*
    @Author ogurchik
    @Task-number1 need to create model for music
    Добавь такие поля как
    String id; - id каждого трека должно быть уникальным и без повторов, найди нужный тип данных для этого
    String title; - название трека
    String author; - автор трека
    String description; - описание трека
    *? time; - время трека, нужно найти тип данных для этого
    *? genre; - название жанра
    *? text; - текст трека
 */
public class Music {
    String id;
    String title;
    String author;
    String description;
    long time;

    public Music(){}

    public Music(String id, String title, String author, String description, long time){
        this.id = id;
        this.title = title;
        this.author = author;
        this.description = description;
        this.time = time;
    }

    public Music(String title, String author, String description, long time) {
        this.title = title;
        this.author = author;
        this.description = description;
        this.time = time;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getAuthor() {
        return author;
    }

    public void setAuthor(String author) {
        this.author = author;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public long getTime() {
        return time;
    }

    public void setTime(long time) {
        this.time = time;
    }


}
