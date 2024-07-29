package com.example.MusicMicroservice.controllers;

import infrastructure.models.Music;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping(value = "/api/v1/music")
public class MusicController {

    @GetMapping
    public Music getMusic(){
        return new Music("qwe","ewq","autor","uuu",1223);
    }

    @PostMapping
    public int getNumber(){
        return 1;
    }
}
