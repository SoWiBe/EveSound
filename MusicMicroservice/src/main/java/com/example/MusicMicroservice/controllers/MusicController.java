package com.example.MusicMicroservice.controllers;

import com.example.MusicMicroservice.infrastructure.models.Music;
import com.example.MusicMicroservice.infrastructure.services.MusicService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping(value = "/api/v1/music")
public class MusicController {

    @Autowired
    private MusicService musicService;

    @PostMapping
    public Music createMusic(@RequestBody Music music) {
        return musicService.createMusic(music);
    }

    @GetMapping("/{id}")
    public Music getMusicById(@PathVariable String id) {
        return musicService.getMusicById(id).orElse(null);
    }

    @GetMapping
    public List<Music> getMusic() {
        return musicService.getAllMusic();
    }

    @PutMapping("/{id}")
    public Music updateMusic(@PathVariable String id, @RequestBody Music music) {
        music.setId(id);
        return musicService.updateMusic(music);
    }
    @DeleteMapping("/{id}")
    public void deleteMusic(@PathVariable String id) {
        musicService.deleteMusic(id);
    }

    @PostMapping("/shuffle")
    public List<Music> shuffleMusic(@RequestBody List<Music> music){
        return musicService.shuffleMusic(music);
    }
}