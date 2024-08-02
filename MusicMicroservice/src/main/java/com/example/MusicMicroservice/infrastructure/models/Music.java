package com.example.MusicMicroservice.infrastructure.models;

import java.util.List;

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
    Author author;
    String description;
    long time;
    List<Genre> genres;

    public Music(){}

    public Music(String id, String title, Author author, String description, long time, List<Genre> genres) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.description = description;
        this.time = time;
        this.genres = genres;
    }

    public Music(String title, Author author, String description, long time, List<Genre> genres) {
        this.title = title;
        this.author = author;
        this.description = description;
        this.time = time;
        this.genres = genres;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public Author getAuthor() {
        return author;
    }

    public void setAuthor(Author author) {
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

    public List<Genre> getGenres() {
        return genres;
    }

    public void setGenres(List<Genre> genres) {
        this.genres = genres;
    }
}
