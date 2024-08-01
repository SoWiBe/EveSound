package com.example.MusicMicroservice.controllers;

import infrastructure.models.Music;
import infrastructure.services.MusicService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping(value = "/api/v1/music")
public class MusicController {

    @Autowired
    private MusicService musicService;

    @PostMapping
    public Music createMusic(@RequestBody Music music){
        return musicService.createMusic(music);
    }

    @GetMapping("/{id}")
    public Music getMusicById(@PathVariable String id){
        return musicService.getMusicById(id).orElse(null);
    }

    @GetMapping
    public List<Music> getMusic() {
        return musicService.getAllMusic();
    }
}
