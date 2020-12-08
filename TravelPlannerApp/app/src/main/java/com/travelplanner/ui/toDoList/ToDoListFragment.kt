package com.travelplanner.ui.toDoList

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.button.MaterialButton
import com.travelplanner.R
import com.travelplanner.ui.localHighlights.LocalHighlightsActivity
import com.travelplanner.ui.localHighlights.LocalHighlightsFragment

class ToDoListFragment : Fragment() {

    lateinit var viewModel: ToDoListViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_to_do_list, container, false)
        viewModel =
                ViewModelProvider(this).get(ToDoListViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        val noData = v.findViewById<LinearLayout>(R.id.no_saved_to_do)
        val button = v.findViewById<MaterialButton>(R.id.add_to_do_item_button)
        val recycler = v.findViewById<RecyclerView>(R.id.to_do_list_recycler)
        val adapter = ToDoListAdapter(activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)){
            viewModel.checkItem(it)
        }
        viewModel.checked.observe(viewLifecycleOwner, Observer {p ->
            adapter.updateCheckbox(p.first, p.second)
        })
        viewModel.toastError.observe(viewLifecycleOwner, Observer {p ->
            Toast.makeText(context, p, Toast.LENGTH_SHORT).show()
        })
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.toDoList.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()){
                noData.visibility = View.GONE
                recycler.visibility = View.VISIBLE
                adapter.setData(it)
            } else {
                noData.visibility = View.VISIBLE
                recycler.visibility = View.GONE
                button.setOnClickListener {
                    //ADD ADDING ACTION
                    val intent = Intent(context, LocalHighlightsActivity::class.java)
                    intent.putExtra(LocalHighlightsFragment.EXTRA_TRAVEL_ID, activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID))
                    context?.startActivity(intent)
                }
            }
        })

        return v
    }

    companion object {
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}