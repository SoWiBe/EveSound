package com.example.MusicMicroservice.controllers;

import com.example.MusicMicroservice.infrastructure.abstractions.StorageService;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.ui.Model;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import java.util.stream.Collectors;

@Controller
public class FileController {

    private StorageService storageService;

    public FileController(StorageService storageService) {
        this.storageService = storageService;
    }

    @GetMapping("/")
    public String listAllFiles(Model model) {
        model.addAttribute("files", storageService.loadAll().map(
                path -> ServletUriComponentsBuilder.fromCurrentContextPath()
                        .path("/download")
                        .path(path.getFileName().toString())
                        .toUriString())
                        .collect(Collectors.toList())
        );

        return "listFiles";
    }


}
