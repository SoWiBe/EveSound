package com.example.MusicMicroservice.controllers;

import infrastructure.Music;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping(value = "/api/v1/music")
public class MusicController {

    @GetMapping
    public List<Music> getAllMusic(){
        var list = new ArrayList<Music>();
        list.add(new Music());
        list.add(new Music());
        list.add(new Music());
        return list;
    }

    @PostMapping
    public int getNumber(){
        return 1;
    }
}
