package com.example.MusicMicroservice.controllers;

import com.example.MusicMicroservice.infrastructure.abstractions.StorageService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.ui.Model;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import java.util.stream.Collectors;

@RestController
@RequestMapping("/api/v1/file")
public class FileController {

    private final StorageService storageService;

    @Autowired
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

    @PostMapping("/load")
    public String handleFileUpload(@RequestParam("file") MultipartFile file) {
        storageService.store(file);
        return "You successfully uploaded " + file.getOriginalFilename() + "!";
    }
}
